using Microsoft.AspNetCore.Mvc;
using DDDRedeSocialUniversitaria.Infra.Interfaces;
using DDDRedeSocialUniversitaria.Domain;

[ApiController]
[Route("api/[controller]")]
public class PostagemController : ControllerBase
{
    private readonly IPostagemRepository _repo;

    public PostagemController(IPostagemRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Postagem>>> GetAll()
    {
        var postagens = await _repo.GetAllAsync();
        return Ok(postagens);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Postagem>> GetById(int id)
    {
        var postagem = await _repo.GetByIdAsync(id);
        if (postagem == null) return NotFound();
        return Ok(postagem);
    }

    [HttpPost]
    public async Task<ActionResult> Add(Postagem postagem)
    {
        await _repo.AddAsync(postagem);
        return CreatedAtAction(nameof(GetById), new { id = postagem.Id }, postagem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Postagem postagem)
    {
        if (id != postagem.Id) return BadRequest();
        await _repo.UpdateAsync(postagem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}
