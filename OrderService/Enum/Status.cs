namespace OrderService.Enum
{
    enum StatusOrder{ 
        New,
        AwaitingPayment,
        Paid,
        TransferredForDelivery,
        Delivered,
        Completed,
    };
}
