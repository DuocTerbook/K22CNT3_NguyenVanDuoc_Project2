// Slider tự động chuyển slide
let slideIndex = 0;
showSlides();

function addToCart(productName, productPrice) {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    const productIndex = cart.findIndex(item => item.name === productName);

    if (productIndex > -1) {
        cart[productIndex].quantity += 1; // Tăng số lượng nếu sản phẩm đã có trong giỏ
    } else {
        cart.push({ name: productName, price: productPrice, quantity: 1 }); // Thêm sản phẩm mới
    }

    localStorage.setItem('cart', JSON.stringify(cart)); // Lưu giỏ hàng vào localStorage
    alert(`${productName} đã được thêm vào giỏ hàng!`);
}

// Tìm kiếm sản phẩm
document.getElementById("search-btn").addEventListener("click", function () {
    const searchQuery = document.getElementById("search").value.toLowerCase();
    const productItems = document.querySelectorAll(".product-item");
    let found = false;

    productItems.forEach(item => {
        const title = item.querySelector("h3").textContent.toLowerCase();
        
        if (title.includes(searchQuery)) {
            found = true;
            item.style.display = "block"; // Hiển thị sản phẩm khớp với tìm kiếm
            item.scrollIntoView({ behavior: "smooth" }); // Cuộn đến sản phẩm
        } else {
            item.style.display = "none"; // Ẩn sản phẩm không khớp
        }
    });

    if (!found) {
        alert("Không tìm thấy sản phẩm nào phù hợp với tìm kiếm của bạn.");
        productItems.forEach(item => item.style.display = "block"); // Hiển thị lại tất cả sản phẩm khi không tìm thấy
    }
});