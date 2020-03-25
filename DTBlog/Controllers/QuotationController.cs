using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DTBlog.Data.Context;
using DTBlog.Data.Model;
using DTBlog.DataAccess.UnitOfWork;
using DTBlog.Helper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DTBlog.Controllers
{
    [IdentityAuthorization]
    public class QuotationController : Controller
    {
        // GET: Quotation
        public IActionResult Index()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<QuotationModel> quotations = uow.GetRepository<QuotationModel>().GetAll()
                    .Include(x => x.UserModel)
                    .Include(x => x.ChangedUser).OrderByDescending(x=>x.ChangedDate).ToList();
                return View(quotations);
            }
        }

        // GET: Quotation/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            QuotationModel quotation = new QuotationModel();

            using (UnitOfWork uow = new UnitOfWork())
            {
                quotation = uow.GetRepository<QuotationModel>().GetAll(x => x.Id == id)
                    .Include(x => x.UserModel)
                    .Include(x => x.ChangedUser).FirstOrDefault();
            }

            if (quotation == null)
                return NotFound();

            return View(quotation);
        }

        // GET: Quotation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quotation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QuotationModel quotationModel)
        {
            var userInfo = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("USER_INFO"));
            quotationModel.ChangedDate = DateTime.Now;
            quotationModel.CreatedDate = DateTime.Now;
            quotationModel.ChangedUserId = userInfo.Id;
            quotationModel.UserId = userInfo.Id;

            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.GetRepository<QuotationModel>().Add(quotationModel);
                    uow.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error", "Home");
        }

        // GET: Quotation/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();


            using (UnitOfWork uow = new UnitOfWork())
            {
                QuotationModel quotationModel = uow.GetRepository<QuotationModel>().Get(x => x.Id == id);
                if (quotationModel != null)
                {
                    return View(quotationModel);
                }
            }

            return NotFound();
        }

        // POST: Quotation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuotationModel quotationModel)
        {
            if (quotationModel == null || quotationModel.Id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        var quot = uow.GetRepository<QuotationModel>().Get(x => x.Id == quotationModel.Id);

                        quot.QuoteContent = quotationModel.QuoteContent;
                        quot.QuoteFrom = quotationModel.QuoteFrom;
                        quot.QuoteImage = quotationModel.QuoteImage;
                        quot.ChangedDate = DateTime.Now;
                        quot.ChangedUserId = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("USER_INFO")).Id;

                        uow.GetRepository<QuotationModel>().Update(quot);
                        uow.SaveChanges();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuotationModelExists(quotationModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Quotation/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (UnitOfWork uow = new UnitOfWork())
            {
                var quotationModel = uow.GetRepository<QuotationModel>().GetAll(x => x.Id == id)
                    .Include(q => q.UserModel)
                    .Include(x => x.ChangedUser).FirstOrDefault();
                if (quotationModel != null)
                    return View(quotationModel);
            }

            return NotFound();
        }

        // POST: Quotation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var quotationModel = uow.GetRepository<QuotationModel>().Get(x => x.Id == id);
                if (quotationModel != null)
                    uow.GetRepository<QuotationModel>().Delete(quotationModel);
                uow.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool QuotationModelExists(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.GetRepository<QuotationModel>().Any(e => e.Id == id);
            }
        }
    }
}
