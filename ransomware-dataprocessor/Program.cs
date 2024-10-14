using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using ransomware_dataprocessor.Data;
using System.Security.Cryptography;
using System.Text;

try 
{
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

    var jsonFileURL = configuration.GetSection("AppSettings")["JsonFileURL"];
    var localFilePath = configuration.GetSection("AppSettings")["LocalFilePath"];
    var duplicateFilePath = configuration.GetSection("AppSettings")["DuplicateFilePath"];

    var connectionUri = configuration.GetConnectionString("DefaultConnection");
    var settings = MongoClientSettings.FromConnectionString(connectionUri);
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);

    var mongoDbClient = new MongoClient(settings);
    var database = mongoDbClient.GetDatabase("RansomwareDB");
    var collection = database.GetCollection<Ransomware>("Ransomware");

    using (var stringReader = new StreamReader(localFilePath))
    {
        var fileContent = await stringReader.ReadToEndAsync();

        var ransomwareList = JsonConvert.DeserializeObject<List<Ransomware>>(fileContent);

        byte[] hashEncode, hashValue;
        List<string> hashList = new List<string>();
        List<Ransomware> duplicateRansomewareList = new List<Ransomware>();

        if (ransomwareList != null)
        {
            foreach (Ransomware ransomeware in ransomwareList)
            {
                hashEncode = ASCIIEncoding.ASCII.GetBytes(ransomeware.ToString());
                hashValue = MD5.HashData(hashEncode);

                if (hashList.Contains(ByteArrayToString(hashValue)))
                {
                    duplicateRansomewareList.Add(ransomeware);
                    //Console.WriteLine("Duplicate");
                    //Console.WriteLine(ransomeware.ToString());
                }
                else
                {
                    hashList.Add(ByteArrayToString(hashValue));
                    collection.InsertOne(ransomeware);
                }
            }
        }

        if (duplicateRansomewareList.Count > 0)
        {
            string duplicateRansomewareListJson = JsonConvert.SerializeObject(duplicateRansomewareList);
            File.WriteAllText(duplicateFilePath, duplicateRansomewareListJson);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Data processing completed.");
    Console.ReadLine();
}
static string ByteArrayToString(byte[] arrInput)
{
    StringBuilder sOutput = new StringBuilder(arrInput.Length);
    for (int i = 0; i < arrInput.Length; i++)
    {
        sOutput.Append(arrInput[i].ToString("X2"));
    }
    return sOutput.ToString();
}

