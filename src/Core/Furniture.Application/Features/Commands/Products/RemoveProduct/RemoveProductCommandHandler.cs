﻿using Furniture.Application.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Application.Features.Commands.Products.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;

        public RemoveProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveAsync();

            return new();
        }
    }
}
