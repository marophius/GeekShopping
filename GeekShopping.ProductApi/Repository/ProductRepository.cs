using AutoMapper;
using GeekShopping.ProductApi.Models;
using GeekShopping.ProductApi.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        private IMapper _mapper;

        public ProductRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ProductVO> Create(ProductVO productVO)
        {
            Product product = _mapper.Map<Product>(productVO);
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null) return false;
                _dataContext.Products.Remove(product);
                await _dataContext.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductVO> GetById(long id)
        {
            return _mapper.Map<ProductVO>(await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<ProductVO>> GetAll()
        {
            return _mapper.Map<List<ProductVO>>(await _dataContext.Products.ToListAsync());
        }

        public async Task<ProductVO> Update(ProductVO productVO)
        {
            Product product = _mapper.Map<Product>(productVO);
            _dataContext.Products.Update(product);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
    }
}
