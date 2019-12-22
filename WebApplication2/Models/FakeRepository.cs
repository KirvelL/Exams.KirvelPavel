using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class UsersRepository
    {
        public static List<User> users = new List<User>();
        public IOrderedEnumerable<User> GetUsers()
        {
            return users.OrderBy(x => x.UserName);
        }

        public void AddUser(string name)
        {
            User user = new User();
            user.UserName = name;
            user.Id = Guid.NewGuid();
            users.Add(user);
        }
        
        public void DeleteUser(Guid id)
        {
            users.Remove(users.Single(x => x.Id == id));
        }
        public void ChangeName(Guid id, string name)
        {
            users.Single(x => x.Id == id).UserName = name;
        }

    }
    public class AccountsRepository
    {
        private static List<Card> accounts = new List<Card>();
        public IOrderedEnumerable<Card> GetCards()
        {
            return accounts.OrderBy(x => x.Number);
        }
        public void AddAccount(string NameOfСardOwner, double summ = 0)
        {
            Card card = new Card();
            card.Summ = summ;
            card.Number = Guid.NewGuid();
            card.NameCardOwner = UsersRepository.users.Single(x => x.UserName == NameOfСardOwner).UserName;
            card.UserId = UsersRepository.users.Single(x => x.UserName == NameOfСardOwner).Id;
            accounts.Add(card);
        }

        public void DeleteAccount(Guid number)
        {
            accounts.Remove(accounts.Single(x => x.Number == number));
        }

        public string Transfer(Guid idPayer, Guid idReceipient, int summ)
        {
            Card acc1 = accounts.Single(x => x.Number == idPayer);
            Card acc2 = accounts.Single(x => x.Number == idReceipient);
            if (acc1.Summ < summ || acc1.Block == true || acc2.Block == true)
            {
                return "Error";
            }
            else
            {
                accounts.Single(x => x.Number == idPayer).Summ -= summ;
                accounts.Single(x => x.Number == idReceipient).Summ += summ;
                return "success";
            }
        }
        public string Deposit(Guid idCard, double summ)
        {
            if (accounts.Single(x => x.Number == idCard).Block == true)
            {
                return "Your card are blocked";
            }
            else
            {
                accounts.Single(x => x.Number == idCard).Summ += summ;
                return $"SUCCESS! + {summ}";
            }
        }
        public void BlockAccount(Guid idCard)
        {
            accounts.Single(x => x.Number == idCard).Block = true;
        }
    }
}
