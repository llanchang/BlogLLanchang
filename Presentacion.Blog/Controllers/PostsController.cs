using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio.Blog;
using Infraestructura.Blog;
using Presentacion.Blog.ViewModel.Post;
using PagedList.EntityFramework;
using System.Text;

namespace Presentacion.Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly ContextoBaseDatos _db;
        private readonly AsignadorTags _asignadorTags;


        public PostsController() : this(new ContextoBaseDatos())
        {

        }

        public PostsController(ContextoBaseDatos contexto) : this(contexto,
            new AsignadorTags(new TagRepositorio(contexto)))
        {

        }
        public PostsController(ContextoBaseDatos contexto, AsignadorTags asignadorTags)
        {
            _db = contexto;
            _asignadorTags = asignadorTags;
        }



        // GET: Posts
        public async Task<ActionResult> Index()
        {
            return View(await _db.Posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        //  [ValidateAntiForgeryToken]        
        public async Task<ActionResult> Create([Bind(Include = "Id,Subtitulo,Titulo,UrlSlug,FechaPost,ContenidoHtml,EsBorrador,FechaPublicacion,Autor")] Post post)
        {
            if (ModelState.IsValid == false)
            {
                _db.Posts.Add(post);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.        
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Subtitulo,Titulo,UrlSlug,FechaPost,ContenidoHtml,EsBorrador,FechaPublicacion,Autor")] Post post)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(post).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Post post = await _db.Posts.FindAsync(id);
            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private async Task<Post> RecuperarPost(int id)
        {
            return await Posts()
                .Include(m => m.Tags)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        private IQueryable<Post> Posts()
        {
            return _db.Posts;
        }
    }
        
}
