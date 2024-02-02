using System.Runtime.InteropServices;

var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Register services
                services.AddDbContext<PrimaryContext>(options => options.UseInMemoryDatabase("Data Source=bank.db"));
                services.AddScoped<BankService>();
                services.AddScoped<BankCustomerService>();
                services.AddScoped<AdminService>();
            })
            .Build();

var bankSvc = ActivatorUtilities.CreateInstance<BankService>(host.Services);
var customerSvc = ActivatorUtilities.CreateInstance<BankCustomerService>(host.Services);
var adminSvc = ActivatorUtilities.CreateInstance<AdminService>(host.Services);

PrintMessageToConsole("Create a new Account", true);

var account = new BankAccount(Guid.NewGuid(), "123456", "Anaya Tech");

bankSvc.AddAccount(account);

PrintMessageToConsole("Account added successfully !", true);
PrintMessageToConsole("");
PrintMessageToConsole("Search for an account with name [Anaya Tech]:", true);

var retrievedAccount = customerSvc.GetAccountByName("Anaya Tech");
if (retrievedAccount is not null)
    PrintMessageToConsole($"Account found: {retrievedAccount}");
else
    PrintMessageToConsole("Account not found.");
PrintMessageToConsole("");
PrintMessageToConsole("Create a new Admin user",true);

adminSvc.AddAdmin(new AdminRecord(1, "Anaya Upadhyay", "upadhyay.anaya@gmail.com"));
PrintMessageToConsole("Admin added successfully!");
PrintMessageToConsole("");
PrintMessageToConsole("Create a new Admin user", true);

adminSvc.AddAdmin(new AdminRecord(2, "Elon Musk", "elon@gmail.com"));
PrintMessageToConsole("Second admin added successfully!");
PrintMessageToConsole("");

PrintMessageToConsole("Get all Admins", true);
var allAdmins = adminSvc.GetAllAdmins();
foreach (var admin in allAdmins)
    PrintMessageToConsole($"{admin}");

PrintMessageToConsole("");

PrintMessageToConsole("End of Primary Constructor usage");
Console.ReadKey();


void PrintMessageToConsole(string message, bool shouldSeparate = false) => 
    Console.WriteLine(
        shouldSeparate
            ? $"{message}\n{new string('-', 50)}"
            : message
    );