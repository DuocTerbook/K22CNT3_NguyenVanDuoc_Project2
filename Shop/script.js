// Tự động chuyển slide
let slideIndex = 0;
function addToCart(id) {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    const listPro = JSON.parse(localStorage.getItem('listProduct')) || [];
    console.log("Giỏ hàng hiện tại:", cart);

    const productIndex = cart.findIndex(item => item.id === id);
    if (productIndex > 0) {
        cart[productIndex].quantity += 1;
    } else {
        var product = listPro.find(item => item.id === id)
        cart.push({id: id, name: product.name, price: product.price, quantity: 1 });
    }

    localStorage.setItem('cart', JSON.stringify(cart));
    alert(`${productName} đã được thêm vào giỏ hàng!`);
    updateCartDisplay();
}

// Hiển thị giỏ hàng
function updateCartDisplay() {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    console.log("Cập nhật hiển thị giỏ hàng:", cart);

    const cartContainer = document.getElementById("cart-display");
    cartContainer.innerHTML = ""; // Xóa nội dung cũ

    cart.forEach(item => {
        const cartItem = document.createElement("div");
        cartItem.classList.add("cart-item");
        cartItem.textContent = `${item.name} - ${item.quantity} x ${item.price} VND`;
        cartContainer.appendChild(cartItem);
    });

    const totalQuantity = cart.reduce((total, item) => total + item.quantity, 0);
    document.getElementById("cart-count").textContent = `(${totalQuantity})`;
}
document.getElementById("search-btn").addEventListener("click", function() {
    const searchValue = document.getElementById("search").value.toLowerCase();
    const products = document.querySelectorAll(".product-item");
    let found = false;

    products.forEach(product => {
        const productName = product.querySelector("h3").textContent.toLowerCase();
        
        if (productName.includes(searchValue)) {
            product.style.display = "block";
            found = true;
        } else {
            product.style.display = "none";
        }
    });

    // Hiển thị thông báo khi không tìm thấy sản phẩm nào
    const resultMessage = document.getElementById("search-result");
    if (found) {
        resultMessage.style.display = "none";
    } else {
        resultMessage.style.display = "block";
    }
});

