
$(document).ready(function () {
    var options = {};
    options.url = "/ShoppingCart/CartSummary";
    options.type = "GET";
    options.dataType = "json";
    options.contentType = "application/json";
    options.success = function (data) {
        $('#deneme42').text('Cart (' + data + ')');
    }
    options.error = function () { $('#deneme42').text('Cart (0)'); };
    $.ajax(options);

});


