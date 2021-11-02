

document.addEventListener("DOMContentLoaded", function () {
    var sidenavElements = document.querySelectorAll(".sidenav");
    M.Sidenav.init(sidenavElements);
    var dropdownElements = document.querySelectorAll(".dropdown-trigger");

    M.Dropdown.init(dropdownElements, {
        hover: false
    });

    var selectElements = document.querySelectorAll("select");
    M.FormSelect.init(selectElements);
    var datepickerElements = document.querySelectorAll("datepicker");
    M.Datepicker.init(datepickerElements);
});