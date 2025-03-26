$(() => {

    loadNewCoffee();

    var connection = new signalR.HubConnectionBuilder().withUrl("/mySignalHub").build();
    connection.start();

    connection.on("LoadCoffee", function () {
        loadNewCoffee();
    })

    loadNewCoffee();

    function loadNewCoffee() {
        var tr = '';
        $.ajax({
            url:"/CoffeePage/Index?handler=CoffeeList",
            method: 'GET',
            success: (result) => {
                var tr = '';
                $.each(result, (k, v) => {
                  tr += `<tr>                       
                    <td>${v.Name}</td>  
                    <td>${v.Description ?? 'N/A'}</td>
                    <td>${v.UnitPrice}</td>
                    <td>${v.StockQuantity}</td>
                    <td>
                        <a href="/CoffeePage/Edit?id=${v.Id}" class="btn btn-primary">Edit</a>
                        <a href="/CoffeePage/Details?id=${v.Id}" class="btn btn-info">Details</a>
                        <a href="/CoffeePage/Delete?id=${v.Id}" class="btn btn-danger">Delete</a>
                    </td>
                </tr>`;
                });
                $('#coffeeTable').html(tr);
            },
            error: (error) => {
                console.log(error);
            }
        })
    }
})
