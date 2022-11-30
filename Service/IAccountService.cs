using CustomerBank.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerBank.Service
{
    public interface IAccountService
    {
        Task <IEnumerable<AccountModel>> GetAccount();
        Task<AccountModel> GetAccountById(string id);
        Task UpdateAccount(string id, AccountModel model);
        Task AddAccount(AccountModel model);
        Task DeleteAccount(string id);
    }
}
