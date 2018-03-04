﻿using System;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderFactory orderFactory;
        private readonly ICustomerOrdersRepository customerOrdersRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPointsCalculator pointsCalculator;

        public OrderService(IOrderFactory orderFactory,
            ICustomerOrdersRepository customerOrdersRepository, IUnitOfWork unitOfWork,
            IPointsCalculator pointsCalculator)
        {
            this.orderFactory = orderFactory;
            this.customerOrdersRepository = customerOrdersRepository;
            this.unitOfWork = unitOfWork;
            this.pointsCalculator = pointsCalculator;
        }

        public OrderPaymentSummary PlaceOrder(OrderDto orderDto)
        {
            var customerOrders = customerOrdersRepository.GetByCustomerId(orderDto.CustomerId);
            customerOrders.PlaceOrder(orderFactory.CreateOrder(orderDto), pointsCalculator);

            customerOrdersRepository.Save(customerOrders);
            unitOfWork.Commit();

            return OrderPaymentSummary.FromCustomerOrders(customerOrders);
        }

        public OrderDto GetById(Guid id)
        {
            return OrderDto.FromDomain(customerOrdersRepository.GetOrderById(id));
        }
    }
}