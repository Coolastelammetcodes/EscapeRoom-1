document.addEventListener("DOMContentLoaded", function () {
  const pageOpenTime = Date.now();

  const goToRoom2 = document.getElementById("goToRoom2");

  if (!goToRoom2) {
    console.log("Room 2 button NOT found (isSolved=false?)");
    return;
  }

  goToRoom2.addEventListener("click", function () {
    const hintEl = document.getElementById("hintCount");

    const hintCount = Number(hintEl?.value || 0);

    const t = pageOpenTime - hintCount * 15000;

    console.log(pageOpenTime + " pageOpenTime");
    console.log(t + " t");

    window.location.href = "http://room2.runasp.net/?t=" + t;
  });
});
