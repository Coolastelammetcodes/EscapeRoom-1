document.addEventListener("DOMContentLoaded", function () {
  const t = Date.now();
  document.getElementById("goToRoom2").addEventListener("click", function () {
    window.location.href = "http://room2.runasp.net/?t=" + t;
  });
});
