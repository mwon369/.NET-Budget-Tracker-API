namespace BudgetTrackerAPI.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _context;

        public TransactionService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> AddTransaction(Transaction transactionToAdd)
        {
            _context.Transactions.Add(transactionToAdd);
            await _context.SaveChangesAsync();
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>?> DeleteTransaction(int id)
        {
            var transactionToDelete = await _context.Transactions.FindAsync(id);
            if (transactionToDelete == null) return null;

            _context.Transactions.Remove(transactionToDelete);

            await _context.SaveChangesAsync();
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>?> EditTransaction(Transaction newTransaction)
        {
            var transactionToEdit = await _context.Transactions.FindAsync(newTransaction.Id);
            if (transactionToEdit == null) return null;

            transactionToEdit.Id = newTransaction.Id;
            transactionToEdit.Value = newTransaction.Value;
            transactionToEdit.Date = newTransaction.Date;
            transactionToEdit.TransactionType = newTransaction.TransactionType;
            transactionToEdit.Description = newTransaction.Description;

            await _context.SaveChangesAsync();
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsFilteredByDetails(TransactionType? transactionType, decimal minValue, decimal? maxValue, string startDate, string endDate, string description)
        {
            var transactionsToReturn = _context.Transactions.Where(t => transactionType == null || t.TransactionType == transactionType)
                                                            .Where(t => maxValue == null || t.Value >= minValue && t.Value <= maxValue)
                                                            .Where(t => startDate == "" && endDate == "" ||
                                                                        startDate == "" && t.Date <= DateTime.Parse(endDate) ||
                                                                        endDate == "" && t.Date >= DateTime.Parse(startDate) ||
                                                                        t.Date >= DateTime.Parse(startDate) && t.Date <= DateTime.Parse(endDate))
                                                            .Where(t => t.Description.ToLower().Contains(description.ToLower()));

            return await transactionsToReturn.ToListAsync();
        }

        public async Task<Transaction?> GetSingleTransactionById(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            return transaction;
        }
    }
}
