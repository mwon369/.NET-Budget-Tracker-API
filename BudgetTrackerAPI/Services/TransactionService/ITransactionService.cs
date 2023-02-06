using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllTransactions();
        Task<List<Transaction>> GetAllTransactionsFilteredByDetails(TransactionType? transactionType, decimal minValue, decimal? maxValue, string startDate, string endDate, string description);
        Task<Transaction?> GetSingleTransactionById(int id);
        Task<List<Transaction>> AddTransaction(Transaction transactionToAdd);
        Task<List<Transaction>?> EditTransaction(Transaction newTransaction);
        Task<List<Transaction>?> DeleteTransaction(int id);
    }
}
