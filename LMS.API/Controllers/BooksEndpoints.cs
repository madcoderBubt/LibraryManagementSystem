using LMS.API.Data;
using LMS.API.Repositories;
using LMS.Shared.DataModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace LMS.API.Controllers;

public static class BooksEndpoints
{
    public static void MapBooksEndpoints (
        this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Books").WithTags(nameof(Books));        

        group.MapGet("/", (IBookRepo bookRepo) =>
        {
            return bookRepo.GetBooks();
        })
        .WithName("GetAllBooks")
        .WithOpenApi();

        group.MapGet("/{id}", (int id, IBookRepo bookRepo) =>
        {
            return bookRepo.GetBook(id);
        })
        .WithName("GetBooksById")
        .WithOpenApi();

        //group.MapPut("/{id}", (int id, Books input) =>
        //{
        //    return TypedResults.NoContent();
        //})
        //.WithName("UpdateBooks")
        //.WithOpenApi();

        group.MapPost("/", async (Books model, IBookRepo bookRepo) =>
        {
            try
            {
                return (await bookRepo.AddOrEditBook(model) ? TypedResults.Ok(model) : TypedResults.BadRequest());
            }
            catch (Exception ex)
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
            //return TypedResults.Created($"/api/Books/{model.BookId}", model);
        })
        .WithName("CreateBooks")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id, IBookRepo bookRepo) =>
        {
            try
            {
                return (await bookRepo.DeleteBook(id) ? TypedResults.Ok("Deleted Successfully") : TypedResults.BadRequest());
            }
            catch (Exception)
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }           
        })
        .WithName("DeleteBooks")
        .WithOpenApi();
    }
}
