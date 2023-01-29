using BudgetTrackerAPI.Enums;

namespace BudgetTrackerAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
