using ComputelNaloga.Data;
using ComputelNaloga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputelNaloga.Controllers
{
    public class CarsController : Controller
    {
        private readonly ComputelNalogaContext _context;

        public CarsController(ComputelNalogaContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Car.ToListAsync());
        }

        // GET: Cars JSON
        [HttpGet("/cars")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Car.ToListAsync();
        }

        // GET: Cars/Details/5
        [HttpGet("carsById")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return Json(car); 
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/CreateCar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("CreateCar")]
        public async Task<IActionResult> Create([Bind("ShortName,Purpose,VehicleMake,License,TrackerDeviceId,Description")] Car car)
        {
            if (car == null)
            {
                return BadRequest("Invalid JSON data");
            }

            car.Purpose = (CarPurpose)Enum.Parse(typeof(CarPurpose), car.Purpose.ToString());
            _context.Car.Add(car);
            await _context.SaveChangesAsync();
            return Ok("Car created successfully");
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("EditCar")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShortName,Purpose,VehicleMake,License,TrackerDeviceId,Description")] Car car)
        {
            car.Purpose = (CarPurpose)Enum.Parse(typeof(CarPurpose), car.Purpose.ToString());

            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(car);
                await _context.SaveChangesAsync();
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpDelete, ActionName("Delete")]
        [Route("DeleteCar")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                _context.Car.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }

        [HttpGet("carPurposeEnumValues")]
        public IActionResult GetEnumValues()
        {
            var enumValues = Enum.GetNames(typeof(CarPurpose));
            return Json(enumValues);
        }
    }
}
