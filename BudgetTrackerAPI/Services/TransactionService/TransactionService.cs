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

        public async Task<List<Transaction>> GetAllTransactionsContainingDescription(string description)
        {
            return await _context.Transactions.Where(t => t.Description.ToLower().Contains(description.ToLower())).ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsFilteredByAmount(decimal minValue, decimal maxValue)
        {
            return await _context.Transactions.Where(t => t.Value >= minValue && t.Value <= maxValue).ToListAsync();
        }

        public async Task<List<Transaction>?> GetAllTransactionsFilteredByDate(string startDate, string endDate)
        {
            if (startDate == "" && endDate == "") return null;

            if (startDate == "") return await _context.Transactions.Where(t => t.Date <= DateTime.Parse(endDate)).ToListAsync();

            if (endDate == "") return await _context.Transactions.Where(t => t.Date >= DateTime.Parse(startDate)).ToListAsync();

            return await _context.Transactions.Where(t => t.Date >= DateTime.Parse(startDate) && t.Date <= DateTime.Parse(endDate)).ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsThatAreIncoming()
        {
            return await _context.Transactions.Where(t => t.TransactionType == TransactionType.INCOMING).ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsThatAreOutgoing()
        {
            return await _context.Transactions.Where(t => t.TransactionType == TransactionType.OUTGOING).ToListAsync();
        }

        public async Task<Transaction?> GetSingleTransactionById(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            return transaction;
        }
    }
}
