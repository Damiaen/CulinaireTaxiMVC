// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

M.AutoInit();

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('select');
    var instances = M.FormSelect.init(elems, options);
});

(function ($) {
    $(function () {


        $('.sidenav').sidenav();
        $('.parallax').parallax();
        $(".dropdown-trigger").dropdown();

        $('.tabs').tabs();

        //$(document).ready(function () {
        //    $('select').formSelect();
        //});
    }); // end of document ready
})(jQuery); // end of jQuery name space