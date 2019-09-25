using RestWithAspNetUdemy.Data.Converter;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null) return new BookVO();
            else
                return new BookVO()
                {
                    Author = origin.Author,
                    id = origin.id,
                    LaunchDate = origin.LaunchDate,
                    Price = origin.Price,
                    Title = origin.Title
                };
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null) return new Book();
            else
                return new Book()
                {
                    Author = origin.Author,
                    id = origin.id,
                    LaunchDate = origin.LaunchDate,
                    Price = origin.Price,
                    Title = origin.Title
                };
        }

        public List<BookVO> ParseList(List<Book> origin)
        {
            if (origin == null) return new List<BookVO>();
            else
                return origin.Select(x => Parse(x)).ToList();
        }

        public List<Book> ParseList(List<BookVO> origin)
        {
            if (origin == null) return new List<Book>();
            else
                return origin.Select(x => Parse(x)).ToList();
        }
    }
}
