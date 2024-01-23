using Amazon.Lambda.Core;
using MySqlConnector;
using System.Text.Json.Serialization;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CSharpAPIGatewayTest;
[JsonSerializable(typeof(BloodPressureModel))]

public class Function
{
    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public string FunctionHandler(BloodPressureModel input, ILambdaContext context)
    {
        string server = "";
        string database = "";
        string username = "";
        string? password = Environment.GetEnvironmentVariable("");
        Console.WriteLine(password);
        string connectionString = String.Format("server={0};database={1};user={2};password={3}", server, database, username, password);
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return ex.Message;
        }
        return "connect";
    }
}
