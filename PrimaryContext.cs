namespace PrimaryConstructor;

public class PrimaryContext(DbContextOptions<PrimaryContext> options) : DbContext(options)
{
    public DbSet<BankAccount> Accounts { get; set; }
    public DbSet<AdminRecord> Admins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BankAccount>(b =>
        {
            b.HasKey(p => p.Id);
        });
    }
}