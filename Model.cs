namespace PrimaryConstructor;

public record BankAccount(Guid Id, string AccountNumber, string AccountHolder)
{
    public override string ToString() => $"{AccountHolder} ({AccountNumber})";
}

public record AdminRecord(int Id, string Name, string Email)
{
    public override string ToString() => $"{Id}: {Name} ({Email})";
}