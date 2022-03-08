

// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Npgsql;
using Microsoft.EntityFrameworkCore;

var client1 = new RestClient("http://dsrcdevops:8080/api/json?tree=jobs%5Bname%2Cbuilds%5Bnumber%2Cactions%5Bparameters%5Bname%2Cvalue%5D%5D%5D%5D&pretty=true");
var request1 = new RestRequest(Method.GET);
request1.AddHeader("postman-token", "43b31178-fd4e-c4aa-1f6c-8813834d4fce");
request1.AddHeader("cache-control", "no-cache");
request1.AddHeader("cookie", "JSESSIONID.1b9147a2=node0ondue41gtx4qs5u30vyhlvsg52.node0");
request1.AddHeader("authorization", "Basic SmVua2luc0FkbWluOkRzcmMxMjM0NQ==");
IRestResponse response1 = client1.Execute(request1);
//Console.WriteLine(response.Content);
//
ProjectModel.Root1 myDeserializedClass1 = JsonConvert.DeserializeObject<ProjectModel.Root1>(response1.Content);
foreach (var dese in myDeserializedClass1.jobs)
{
    string project = dese.name;
    var client = new RestClient("http://dsrcdevops:8080/job/" + project + "/lastBuild/api/json");
    var request = new RestRequest(Method.GET);
    request.AddHeader("postman-token", "fccbb11d-18a0-08d9-43af-f9c48951f097");
    request.AddHeader("cache-control", "no-cache");
    request.AddHeader("cookie", "JSESSIONID.1b9147a2=node0ondue41gtx4qs5u30vyhlvsg52.node0");
    request.AddHeader("authorization", "Basic SmVua2luc0FkbWluOkRzcmMxMjM0NQ==");
    IRestResponse response = client.Execute(request);

    try
    {
        Sample.Root myDeserializedClass = JsonConvert.DeserializeObject<Sample.Root>(response.Content);
        foreach (var item in myDeserializedClass.actions)
        {

            if (item.build != null)
            {
                //Console.WriteLine(dese.name + " - " + item.build.marked.branch[0].name);
                var cs = "Host=localhost;Port=5432;Database=Sample;User Id=postgres;Password=H@R$sh12;";
                using var con = new NpgsqlConnection(cs);
                con.Open();
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                int length = item.build.marked.branch.Count - 1;
                cmd.CommandText = "INSERT INTO DSRC(ProjectName,BranchName) VALUES('" + dese.name + "','" + item.build.marked.branch[length].name + "')";
                cmd.ExecuteNonQuery();
                Console.WriteLine(dese.name + " : Inserted into the Database");
            }
        }
    }
    catch (Exception e)
    {
        //"+dese.name+","+item.build.marked.branch[0].name+"
        Console.WriteLine(dese.name + " : Not Found");

    }
}

//ProjectModel.Project context = new ProjectModel.Project();
//var query=from it in context.ProjectName
//          select it;    
//foreach(var pro in query)
//{
//    Console.WriteLine(pro);
//}
Console.ReadLine();



