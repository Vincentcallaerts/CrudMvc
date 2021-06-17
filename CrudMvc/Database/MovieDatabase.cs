using CrudMvc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMvc.Database
{
    public interface IMovieDatabase
    {
        Movie GetMovie(int id);
        IEnumerable<Movie> GetMovies();
        Movie Insert(Movie movie);
        void Delete(int id);
        void Update(int id, Movie updatedMovie);
    }

    public class MovieDatabase : IMovieDatabase
    {
        private int counter;
        private readonly List<Movie> movies;

        public MovieDatabase()
        {
            if (movies == null) 
            {
                movies = new List<Movie>();
            }
        }

        public Movie GetMovie(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }

        public Movie Insert(Movie movie)
        {
            counter++;
            movie.Id = counter;
            movies.Add(movie);
            return movie;
        }

        public void Delete(int id)
        {
            var movie = movies.SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
            }
            
        }

        public void Update(int id, Movie updatedMovie)
        {
            var movie = movies.SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                movie.Title = updatedMovie.Title;
                movie.Description = updatedMovie.Description;
                movie.Genre = updatedMovie.Genre;
            }
        }
    }
}
