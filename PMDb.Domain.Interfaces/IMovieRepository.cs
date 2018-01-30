﻿using PMDb.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMDb.Domain.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        void AddMark(double mark);
        void UpdateMark(int movieId);
        void DeleteMark(int movieId);
        void Save();
    }
}
