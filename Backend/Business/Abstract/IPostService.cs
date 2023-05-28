﻿using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<List<Post>> GetAll();
        IDataResult<Post> GetById(int postId);
        IResult Add(Post post);
        IResult Update(Post post);
        IResult Delete(Post post);
    }
}