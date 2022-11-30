using CustomerBank.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerBank.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerBank.Service
{
    public class AccountService : IAccountService
    {
        private readonly CustomerStoreContext _context;
        public AccountService(CustomerStoreContext account)
        {
            _context = account;
        }
        public async Task<IEnumerable<AccountModel>> GetAccount()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<AccountModel> GetAccountById(string id)
        {
            return await _context.Account.FirstOrDefaultAsync(b => b.AccountNumber == id);
        }

        public async Task AddAccount(AccountModel model)
        {
            await _context.Account.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccount(string id, AccountModel model)
        {
            var AccntDb = await _context.Account.FirstOrDefaultAsync(b => b.AccountNumber == id);

            if (AccntDb != null)
            {
                AccntDb.AccountType = model.AccountType;
                AccntDb.SubAccountType = model.SubAccountType;
                AccntDb.RateOfInterest = model.RateOfInterest;
                AccntDb.CardNumber = model.CardNumber;
                AccntDb.IsActive = model.IsActive;
                AccntDb.CurrencyType = model.CurrencyType;
                AccntDb.Branch = model.Branch;
                AccntDb.IFSCCode = model.IFSCCode;

            }

        }

        public async Task DeleteAccount(string id)
        {
            var AccntDb = await _context.Account.FirstOrDefaultAsync(b => b.AccountNumber == id);
            if (AccntDb != null)
            {
                _context.Account.Remove(AccntDb);
                await _context.SaveChangesAsync();
            }
        }
    }
}
