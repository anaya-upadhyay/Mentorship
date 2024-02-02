namespace PrimaryConstructor;

public class BankCustomerService(BankService bankService)
{
    public BankAccount GetAccountByName(string accountName)
    {
        return bankService.GetAccountByName(accountName);
    }
}
