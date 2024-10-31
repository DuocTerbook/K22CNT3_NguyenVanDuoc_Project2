document.getElementById("loginForm").addEventListener("submit", function(event) {
    event.preventDefault(); // Ngăn không cho form tự động submit

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    if (username === "nvd" && password === "123456789") {
        window.location.href = "index.html";
    } else {
        alert("Tài khoản hoặc mật khẩu không đúng!");
    }
});