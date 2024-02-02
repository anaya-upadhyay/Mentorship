namespace PrimaryConstructor;

public class AdminService(PrimaryContext context)
{
    public void AddAdmin(AdminRecord admin)
    {
        context.Admins.Add(admin);
        context.SaveChanges();
    }

    public IEnumerable<AdminRecord> GetAllAdmins()
    {
        return context.Admins.ToList();
    }
}
