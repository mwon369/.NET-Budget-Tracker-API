using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllTransactions();
        Task<List<Transaction>> GetAllTransactionsFilteredByAmount(decimal minValue, decimal maxValue);
        Task<List<Transaction>> GetAllTransactionsFilteredByDate(string startDate, string endDate);
        Task<List<Transaction>> GetAllTransactionsThatAreIncoming();
        Task<List<Transaction>> GetAllTransactionsThatAreOutgoing();
        Task<List<Transaction>> GetAllTransactionsContainingDescription(string description);
        Task<Transaction> GetSingleTransactionById(int id);
        Task<List<Transaction>> AddTransaction(Transaction transactionToAdd);
        Task<List<Transaction>> EditTransaction(Transaction newTransaction);
        Task<List<Transaction>> DeleteTransaction(int id);
    }
}
