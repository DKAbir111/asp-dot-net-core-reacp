$(function () {


    function DisplayResult1(call, data) {

        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $.each(data, function (i, item) {

            $('#result').append(JSON.stringify(item));
            $('#result').append("<br/>");
        });
    };

    function DisplayResult2(call, data) {

        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $('#result').append(JSON.stringify(data));
        $('#result').append("<br/>");

    };

    function LoadBooks(data) {
        //alert("Hello");
        $.each(data, function (i, item) {
            var tableRow = '<tr>' +
                '<td>' + item.id + '</td>' +
                '<td>' + item.title + '</td>' +
                '<td>' + item.author + '</td>' +
                '<td>' + item.publicationYear + '</td>' +
                '<td>' + item.isAvailable + '</td>' +
                '<td>' + item.callNumber + '</td>' +
                //uncomment only after cost is returned.
                //'<td>' + item.costId + '</td>' +
                //'<td>' + item.cost.price + '</td>' +
                //'<td>' + item.cost.discountCode + '</td>' +
                '</tr>';
            $('#booksTable').append(tableRow);
        });
    };



    //url and port number of web api/ postman
    var serviceUrl = 'https://localhost:44329/api';
    $('#GetAll').on('click', function () {
        $.ajax({
            url: serviceUrl + '/books',
            method: 'GET',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                LoadBooks(data);
                //DisplayResult1("Get All", data);
            }
        });
    });


    $('#AddBook').on('click', function () {
        //form encoded data
        //var dataType = 'application/x-www-form-urlencoded; charset=utf-8';
        var inputData = $('input').serialize();
        //alert(inputData);
        $.ajax({
            url: serviceUrl + '/books',
            method: 'POST',
            //contentType: dataType,
            data: JSON.stringify(inputData),
            success: function (data) {
                DisplayResult2("Add Book", data);
            }
        });
    });


    $('#GetById').on('click', function () {
        //var inputData = $('input').serialize();
        var bookId = $('#id').val();
        $.ajax({
            url: serviceUrl + '/books/' + bookId,
            method: 'GET',
            //data: inputData,
            success: function (data) {
                DisplayResult2("Get By book Id:", data);
            }
        });
    });


    $('#AddCost').on('click', function () {
        var dataType = 'application/x-www-form-urlencoded; charset=utf-8';
        var inputdata = $('input').serialize();
        $.ajax({
            url: serviceUrl + '/books/updatecost/' + $('#BookId').val(),
            method: 'PUT',
            data: inputdata,
            success: function (data) {
                DisplayResult2("Add Cost", data);
            }
        });
    });


});
