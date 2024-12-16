﻿using DangTienDaoVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangTienDaoVien.DataAccess.Repository.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public void Update(Comment comment); 
    }
}
