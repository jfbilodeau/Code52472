// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using Microsoft.Identity.Client;

Console.WriteLine("Starging MSAL demo!");

var tenantId = "YOUR_TENANT_ID";
var clientId = "YOUR_CLIENT_ID";

var scopes = new string[] { 
    "user.read",
    "https://management.azure.com/user_impersonation"
};

var app = PublicClientApplicationBuilder
    .Create(clientId)
    .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
    .WithDefaultRedirectUri()
    .Build();

var account = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

if (account == null)
{
    Console.WriteLine("Could not acquired token!");
    return;
}   

var token = account.AccessToken.Substring(0, account.AccessToken.Length - 10);

Console.WriteLine($"Username: {account.Account.Username}");

Console.WriteLine($"Token: {token}");

Console.WriteLine("Done!");