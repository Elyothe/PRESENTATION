using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.ApiDbContexts;
using API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSuccesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public UserSuccesController(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère la liste des succès (badges) d'un utilisateur donné.
        /// </summary>
        /// <param name="idUser">L'ID de l'utilisateur.</param>
        /// <returns>La liste des succès de l'utilisateur.</returns>
        [HttpGet("GetByUserId/{idUser}")]
        public async Task<ActionResult<IEnumerable<succes>>> GetUserSuccesByUserId(int idUser)
        {
            var userSuccesList = await _context.UserSucces
                .Where(us => us.idUser == idUser)
                .Include(us => us.Succes) // Inclure les détails du succès
                .ToListAsync();

            if (userSuccesList == null || userSuccesList.Count == 0)
            {
                return NotFound(new { message = "Aucun succès trouvé pour cet utilisateur." });
            }

            var succesList = userSuccesList.Select(us => us.Succes).ToList();
            return Ok(succesList);
        }

        /// <summary>
        /// Ajoute un succès à un utilisateur.
        /// </summary>
        /// <param name="userSucces">Objet UserSucces à ajouter.</param>
        /// <returns>Le succès ajouté.</returns>
        [HttpPost("Add")]
        public async Task<ActionResult<userSucces>> AddUserSucces(userSucces userSucces)
        {
            if (userSucces == null)
            {
                return BadRequest("Les données de UserSucces ne peuvent pas être nulles.");
            }

            _context.UserSucces.Add(userSucces);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserSuccesByUserId), new { idUser = userSucces.idUser }, userSucces);
        }

        /// <summary>
        /// Supprime un succès d'un utilisateur.
        /// </summary>
        /// <param name="idUser">L'ID de l'utilisateur.</param>
        /// <param name="idSucces">L'ID du succès à supprimer.</param>
        /// <returns>Statut de la suppression.</returns>
        [HttpDelete("Delete/{idUser}/{idSucces}")]
        public async Task<IActionResult> DeleteUserSucces(int idUser, int idSucces)
        {
            var userSucces = await _context.UserSucces
                .FirstOrDefaultAsync(us => us.idUser == idUser && us.idSucces == idSucces);

            if (userSucces == null)
            {
                return NotFound(new { message = "Le succès à supprimer n'a pas été trouvé." });
            }

            _context.UserSucces.Remove(userSucces);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}  
