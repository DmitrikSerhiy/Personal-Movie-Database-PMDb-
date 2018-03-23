﻿using PMDb.Services.Helpers;
using PMDb.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMDb.Services
{
    public interface IMovieService
    {
        MovieModel GetMovie(int Id);
        IList<SimplifiedMovieModel> GetMovies(PaginationParameters getMoviesParameters);
        bool IsMovieExist(int movieId);
        bool IsMovieExist(string movieName);
        void UpdateMark(int movieId, double newMark);
        void DeleteMark(string movieName);
        string GeneratePreviousPageLink(bool hasPrevious, PaginationParameters getMoviesParameters);
        string GenerateNextPageLink(bool hasNext, PaginationParameters getMoviesParameters);

    }
}
