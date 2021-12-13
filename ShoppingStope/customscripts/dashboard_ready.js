window.onload = function () {
    $.ajax({
        url: '/Admin/Addproduct',
        type: 'GET',
        success: function (Result) {
            $('#main').html(Result);
        }

    });
};