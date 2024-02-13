﻿using KodlamaIOClone.Business.Abstracts;
using KodlamaIOClone.Business.Dtos.Requests;
using KodlamaIOClone.Business.Dtos.Response;
using KodlamaIOClone.DataAccess.Abstracts;
using KodlamaIOClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIOClone.Business.Concretes
{
   public class TutorManager : ITutorService
    {
        ITutorDal _tutorDal;
        public TutorManager(ITutorDal tutorDal)
        {
            _tutorDal = tutorDal; 
        }
        public void Add(AddTutorRequest tutor)
        {
            Random rnd = new Random();
            Tutor dtoToTutor = new Tutor();
            dtoToTutor.Id = (int)rnd.NextInt64(0, 100);
            _tutorDal.Add(dtoToTutor);
        }
        public void Delete(DeleteTutorRequest tutor)
        {
            Tutor deleteForTutor = new Tutor();
            deleteForTutor = _tutorDal.GetById(tutor.Id);
            _tutorDal.Delete(deleteForTutor);
        }
        public List<GetAllTutorResponse> getAllTutor()
        {
            List<GetAllTutorResponse> tutorlist = new List<GetAllTutorResponse>();
            foreach (var item in _tutorDal.GetAll())
            {
                tutorlist.Add(new GetAllTutorResponse { Id = item.Id, FullName = item.FullName, TutorImageUrl = item.TutorImageUrl,});
            }
            return tutorlist;
        }
        public GetByIdTutorResponse getByIdTutor(int id)
        {
            GetByIdTutorResponse getallTutorResponse = new GetByIdTutorResponse();
            Tutor tutor = _tutorDal.GetById(id);
            getallTutorResponse.Id = tutor.Id;
            getallTutorResponse.FullName = tutor.FullName;
            return getallTutorResponse;
        }
        public void Update(UpdateTutorRequest tutor)
        {
            Tutor tutorUpdate = new Tutor();
            tutorUpdate.Id = tutor.Id;
            tutorUpdate.FullName = tutor.FullName;
            tutorUpdate.TutorImageUrl = tutor.TutorImageUrl;
            _tutorDal.Update(tutorUpdate);
        }
    }
}
