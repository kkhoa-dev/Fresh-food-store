/*Back to top*/
$('.back-to-top').click(function () {
    $('html, body').animate({
        scrollTop: 0
    }, 600);
    return false;
});

$(function () {
    // Instantiate EasyZoom instances
    var $easyzoom = $('.easyzoom').easyZoom();

    // Setup thumbnails example
    var api1 = $easyzoom.filter('.easyzoom--with-thumbnails').data('easyZoom');

    $('.thumbnails').on('click', 'a', function (e) {
        var $this = $(this);

        e.preventDefault();

        // Use EasyZoom's `swap` method
        api1.swap($this.data('standard'), $this.attr('href'));
    });
});


$(".input_Image").change(function () {
    readURL(this);
});

$(".btn-image").click(function () {
    $(this).closest("form div").find(".input_Image").click();
    //$(".input_Image").click();

})

/*login-register*/

function changeContent(e, content) {
    $(".li").attr("class", "li");
    $(e).attr("class", "li active");
    $(".input-login-register").fadeOut(1);
    $("#" + content).fadeIn(1);
}
/*end login-register*/


function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(input).closest("form div").find(".img_Preview").attr('src', e.target.result);
            // $.('.img_Preview').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        loadCart();
    }
    function loadCart() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListItems',
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
            }
        });
    }
    function regsiterEvents() {
        // Write your JavaScript code.
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture + '/Cart/AddToCart',
                data: {
                    id: id,
                    languageId: culture
                },
                success: function (res) {
                    $('#lbl_number_items_header').text(res.length);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });
    }
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}