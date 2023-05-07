﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Contact;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll());
        }

        public IDataResult<List<Contact>> GetById(int contactId)
        {
            var result = _contactDal.GetAll(c => c.ContactId == contactId);
            return new SuccessDataResult<List<Contact>>(result, Messages.ContactListed);
        }

        public IDataResult<List<Contact>> GetContactsByUserId(int userId)
        {
            var result = _contactDal.GetAll(c => c.UserId == userId);
            return new SuccessDataResult<List<Contact>>(result, Messages.ContactListed);
        }

        public IResult Add(ContactForCreateDto contact)
        {
            var check = CheckIfContactExists(contact.ContactId, contact.UserId);
            if (check)
            {
                return new ErrorResult(Messages.ContactExists);
            }

            var checkLimit = CheckIfLimitExceeded(contact.UserId);
            if (checkLimit)
            {
                return new ErrorResult(Messages.ContactLimitExceeded);
            }

            var result = new Contact()
            {
                UserId = contact.UserId,
                ContactId = contact.ContactId,
                ContactRelation = contact.ContactRelation
            };

            _contactDal.Add(result);
            
            return new SuccessResult(Messages.ContactAdded);
        }

        public IResult Update(ContactForCreateDto contact)
        {
            var check = CheckIfContactExists(contact.ContactId, contact.UserId);
            if (!check)
            {
                return new ErrorResult(Messages.ContactNotFound);
            }

            var result = new Contact()
            {
                Id = contact.Id,
                UserId = contact.UserId,
                ContactId = contact.ContactId,
                ContactRelation = contact.ContactRelation
            };

            _contactDal.Update(result);
            return new SuccessResult(Messages.ContactUpdated);
        }

        public IResult Delete(ContactForCreateDto contact)
        {
            var check = CheckIfContactExists(contact.ContactId, contact.UserId);
            if (!check)
            {
                return new ErrorResult(Messages.ContactNotFound);
            }

            var result = new Contact()
            {
                Id = contact.Id,
                UserId = contact.UserId,
                ContactId = contact.ContactId,
                ContactRelation = contact.ContactRelation
            };

            _contactDal.Delete(result);
            return new SuccessResult(Messages.ContactDeleted);
        }

        private bool CheckIfContactExists(int contactId, int userId)
        {
            var result = _contactDal.GetAll(c => c.ContactId == contactId && c.UserId == userId);
            if (result.Count > 0)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfLimitExceeded(int userId)
        {
            var result = _contactDal.GetAll(c => c.UserId == userId);
            if (result.Count == 5)
            {
                return true;
            }
            return false;
        }
    }
}
