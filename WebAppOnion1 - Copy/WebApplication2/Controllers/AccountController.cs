using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        AccountsRepository accrepository = new AccountsRepository();

        [Route("/accounts")]
        [HttpGet]
        public List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();
            foreach (var a in accrepository.GetCards())
            {
                cards.Add(a);
            }
            return cards;
        }

        [Route("/accounts/{idCard}/delete")]
        [HttpDelete]
        public string DeleteAccount(Guid id)
        {
            accrepository.DeleteAccount(id);
            return $"success!";
        }

        [Route("/accounts/{idCard}/block")]
        [HttpPost]
        public string Block(Guid idCard)
        {
            accrepository.BlockAccount(idCard);
            return $"success!";
        }

        [Route("/accounts/{idCard}/deposite")]
        [HttpPost]
        public string Deposite(Guid id)
        {
            accrepository.Deposit(id, 50);
            return $"success!";
        }
        [Route("/accounts/{nickOwner}/AddCard")]
        [HttpPost]
        public string AddAccount(string nickOwner)
        {
            accrepository.AddAccount(nickOwner);
            return $"success!";
        }
        [Route("/accounts/{idPayer}/transfer/{idReceipient}")]
        [HttpPost]
        public string Transfer(Guid idPayer, Guid idReceipient)
        {
            string message = accrepository.Transfer(idPayer, idReceipient, 40);
            return message;
        }
    }
}
