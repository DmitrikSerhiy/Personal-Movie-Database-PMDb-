﻿using PMDb.Domain.Interfaces;
using PMDb.Services.Helpers;
using PMDb.Services.Mappers;
using PMDb.Services.Models;
using PMDb.Services.ServicesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMDb.Services
{
    public class MovieListService : IMovieListService
    {
        private IMovieListRepository movieListRepository;


        public MovieListService(IMovieListRepository MovieListRepository)
        {
            movieListRepository = MovieListRepository;
        }

        public MovieListModel AddMovieToList(string movieName, string movieListName)
        {
            var movieList = movieListRepository.AddMovieToList(movieName, movieListName);
            movieListRepository.Save();
            var mapppedMovieList = MovieListMapper.Map(movieList);
            PageMovieList(ref mapppedMovieList);
            return mapppedMovieList;
        }

        public MovieListModel CreateMovieList(string Name, bool IsDefault = false)
        {
            var movieList = IsDefault != true ? 
                movieListRepository.CreateMovieList(Name) :
                movieListRepository.CreateMovieList(Name, true);//create default movieList

            movieListRepository.Save();
            var mapppedMovieList = MovieListMapper.Map(movieList);
            PageMovieList(ref mapppedMovieList);
            return mapppedMovieList;
        }


        private void PageMovieList(ref MovieListModel movieListModel)
        {
            PaginationParameters defaultParameters = new PaginationParameters();
            movieListModel.Movies = PagedList<SimplifiedMovieModel>.Create(
                movieListModel.Movies,
                defaultParameters.PageNumber,
                defaultParameters.PageSize);
        }

        public MovieListModel DeleteMovieFromList(string movieName, string movieListName)
        {
            var movieList = movieListRepository.DeleteMovieFromList(movieName, movieListName);
            movieListRepository.Save();

            var mapppedMovieList = MovieListMapper.Map(movieList);
            PageMovieList(ref mapppedMovieList);
            return mapppedMovieList;
        }

        public void DeleteMovieList(string MovieListName)
        {
            if (movieListRepository.GetMovieList(MovieListName).IsDefault != true)
            {
                movieListRepository.DeleteMovieList(MovieListName);
                movieListRepository.Save();
            }
        }

        public void DeleteDefaultMovieList(string MovieListName)
        {
            movieListRepository.DeleteMovieList(MovieListName);
            movieListRepository.Save();
        }

        public MovieListModel GetMovieList(string MovieListName)
        {
            var movieList = movieListRepository.GetMovieList(MovieListName);
            var mapppedMovieList = MovieListMapper.Map(movieList);
            PageMovieList(ref mapppedMovieList);
            InitBoolFields(ref mapppedMovieList);
            return mapppedMovieList;
        }

        public void InitBoolFields(ref MovieListModel moviesList)
        {
            moviesList.Movies.ForEach(m =>
            {
                m.HasTags = m.Tags.Count != 0;
                m.HasReview = !String.IsNullOrEmpty(m.Review);
                m.ListsWithCurrMovie = ListOfMovieListsMapper.Map(
                    movieListRepository.GetMovieListMovieForMovie(m.Title));
                m.IsInWatchLater = m.ListsWithCurrMovie.Any(lwcm => lwcm.MovieListName == "WatchLater");
                m.IsInFavoriteList = m.ListsWithCurrMovie.Any(lwcm => lwcm.MovieListName == "Favorite");
            });
        }

        public MovieListModel UpdateMovieListName(string oldName, string newName)
        {
            var movieList = movieListRepository.UpdateMovieListName(oldName, newName);
            movieListRepository.Save();
            var mapppedMovieList = MovieListMapper.Map(movieList);
            PageMovieList(ref mapppedMovieList);
            return mapppedMovieList;
        }

        public bool IsMovieExistInList(string movieListName, string movieName)
        {
            return movieListRepository.IsMovieExistInList(movieListName, movieName);
        }


        public bool IsMovieListExist(string movieListName)
        {
            return movieListRepository.IsMovieListExist(movieListName);
        }

        public bool IsMovieExist(string movieName)
        {
            return movieListRepository.IsMovieExist(movieName);
        }
    }
}
