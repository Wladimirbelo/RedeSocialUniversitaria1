using Microsoft.AspNetCore.Mvc;
using DDDRedeSocialUniversitaria.Infra.Interfaces;
using DDDRedeSocialUniversitaria.Domain;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly IEventosRepository _repo;

    public EventoController(IEventosRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evento>>> GetAll()
    {
        var eventos = await _repo.GetAllAsync();
        return Ok(eventos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Evento>> GetById(int id)
    {
        var evento = await _repo.GetByIdAsync(id);
        if (evento == null) return NotFound();
        return Ok(evento);
    }

    [HttpPost]
    public async Task<ActionResult> Add(Evento evento)
    {
        await _repo.AddAsync(evento);
        return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Evento evento)
    {
        if (id != evento.Id) return BadRequest();
        await _repo.UpdateAsync(evento);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}
