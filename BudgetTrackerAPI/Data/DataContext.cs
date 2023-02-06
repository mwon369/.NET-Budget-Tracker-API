namespace BudgetTrackerAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=transactiondb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
