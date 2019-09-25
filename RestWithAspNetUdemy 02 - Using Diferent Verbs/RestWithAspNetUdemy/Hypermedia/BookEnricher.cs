using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestWithAspNetUdemy.Data.VO;
using System;
using RestWithAspNetUdemy.Models;

namespace RestWithAspNetUdemy.Hypermedia
{
    public class BookEnricher : ObjectContentResponseEnricher<BookVO>
    {
        protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
        {
            var path = "api/v1/Books/";
            var url = new { controller = path, id = content.id };
            var req = urlHelper.ActionContext.HttpContext.Request;            
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = String.Format("{0}/{1}/{2}{3}", req.Scheme, req.Host, url.controller, url.id),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.POST,
                    Href = String.Format("{0}/{1}/{2}", req.Scheme, req.Host, url.controller),
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultPost
                });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = String.Format("{0}/{1}/{2}", req.Scheme, req.Host, url.controller),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = String.Format("{0}/{1}/{2}{3}", req.Scheme, req.Host, url.controller, url.id),
                Rel = RelationType.self,
                Type = "int"
            });
            return null;
        }
    }
}
