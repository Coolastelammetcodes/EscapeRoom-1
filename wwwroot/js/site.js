document.addEventListener("DOMContentLoaded", function () {

    if (!localStorage.getItem('escapeStartTime')) {
        localStorage.setItem('escapeStartTime', Date.now());
    }

    var t = localStorage.getItem('escapeStartTime');
    window.location.href = 'http://room2.runasp.net/?t=' + t;
});