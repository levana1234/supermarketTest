using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTest.Dto;
using TestTest.Entity;

namespace TestTest.Controllers
{

    public class MarketControler : ControllerBase
    {
        public readonly MarketDbContext _context;

        public MarketControler(MarketDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-market")]



        public async Task<ActionResult<ServiceResponce<string>>> GetFilmMsaxiobebi1(Market market)
        {
            _context.markets.Add(market);
            _context.SaveChanges();
            var x = new ServiceResponce<string>();
            x.Massage = "warmatebit sheiqmna";
            return x;
        }
        [HttpPost("crete-product")]
        public async Task<ActionResult<ServiceResponce<string>>> ProdutcCreate(Product product)
        {
           await  _context.products.AddAsync(product); 
             _context.SaveChanges();
            var x = new ServiceResponce<string>();
            x.Massage = "warmatebuli";

            return   x;
        }

        [HttpPost("create-makrket_product")]
        public async Task<ActionResult<ServiceResponce<string>>> addMarketproduct(market_protuct market_Protuct)
        {
            await _context.market_Protucts.AddAsync(market_Protuct);
            _context.SaveChanges();

            var x = new ServiceResponce<string>();

            x.Massage = "warmatebul";
            return x;
        }
        [HttpPost ("create_personal")]
        public async Task<ActionResult <ServiceResponce<string>>> createPersonal(Personal personal)
        {
           await _context.personals.AddAsync(personal);
            _context.SaveChanges();
            var x = new ServiceResponce<string>();
            x.Massage = "warmatebuli";
            return x;
        }

        [Authorize]
        [HttpGet("get_all_personal")]

        public async Task<ActionResult<ServiceResponce<List<Dtooooooo>>>> getAll()
        {
            var z = await _context.personals.Include(x=> x.market).Select(x=> new Dtooooooo()
            {
             
                Name = x.Name,
                Age =x.Age,
                 Market_Name = x.market.Name,
                 Description = x.market.Description,
            }).ToListAsync();

            var c = new ServiceResponce<List<Dtooooooo>>();
            c.Data = z;

            return  c;
        }

        [HttpGet("get-all")] 
        public async Task<ActionResult<ServiceResponce<List< market_protuct>>>>Getallmarketproduct ()
        {
            var z = await _context.market_Protucts
                .Include(x => x.market)
                .Include(X => X.product).Select(x => new market_protuct()
                {
                    market = x.market,
                    product = x.product
                }).ToListAsync();
                
                
               

           

            var b = new ServiceResponce<List<market_protuct>>();
            b.Data = z;

            return b;
           
        }

       
    }
}
