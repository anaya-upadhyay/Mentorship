namespace PrimaryConstructor;

public class BankService(PrimaryContext context)
{
    public void AddAccount(BankAccount account)
    {
        context.Accounts.Add(account);
        context.SaveChanges();
    }

    public BankAccount GetAccountByName(string accountName)
    {
        return context.Accounts.SingleOrDefault(a => a.AccountHolder == accountName)!;
    }


}
