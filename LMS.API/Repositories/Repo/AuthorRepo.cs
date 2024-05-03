using LMS.API.Data;
using LMS.API.Repositories;
using LMS.Shared.DataModel;
using System.Diagnostics.CodeAnalysis;

namespace LMS.API.Repositories.Repo
{
    internal class AuthorRepo : IAuthorRepo
    {
        private readonly AppDBContext _dbContext;
        public AuthorRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[return: MaybeNull]
        async Task<bool> IAuthorRepo.AddOrEditAuthor([NotNull]Authors authors)
        {
            //if (authors is null) return null;

            if (authors is { AuthorId: > 0})
            {
                //Edit Oparation
                _dbContext.Authors.Update(authors);
            }
            else
            {
                //Add Oparation
                await _dbContext.AddAsync(authors);
            }

            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        async Task<bool> IAuthorRepo.DeleteAuthor(int authorId)
        {
            var result = _dbContext.Authors.Find(authorId);
            if(result != null)
            {
                _dbContext.Authors.Remove(result);
                var res = await _dbContext.SaveChangesAsync();
                return (res > 0);
            }
            return false;
        }

        [return: MaybeNull]
        Authors IAuthorRepo.GetAuthor(int authorId)
        {
            return _dbContext.Authors.Find(authorId);
        }

        List<Authors> IAuthorRepo.GetAuthors()
        {
            return _dbContext.Authors.ToList();
        }
    }
}
