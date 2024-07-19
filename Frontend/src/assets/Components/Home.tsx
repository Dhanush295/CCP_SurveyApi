import axios from 'axios';
import { useState, useEffect } from 'react';

export function Home() { // Named export
    const [email, setEmail] = useState<string>('');
    const [address, setAddress] = useState<string>('');
    const [county, setCounty] = useState<string>('');
    const [state, setState] = useState<string>('');
    const [zipcode, setZipcode] = useState<string>('');
    const [formSubmitted, setFormSubmitted] = useState<boolean>(false);

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault(); 
        setFormSubmitted(true); 
    };

    useEffect(() => {
        const submitForm = async () => {
            try {
                const response = await axios.post('http://localhost:5119/api/surveyOne', {
                    email,
                    address,
                    county,
                    state,
                    zipcode,
                });

                console.log(response.data);

                if (response.data != null) {
                    window.location.assign('/submitted');
                }
            } catch (error) {
                console.error('Error during creating: ', error);
            }
        };

        if (formSubmitted) {
            submitForm();
            setFormSubmitted(false); // Reset formSubmitted to false after form submission
        }
    }, [formSubmitted, email, address, county, state, zipcode]);

    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-100">
            <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
                <h2 className="text-2xl font-bold mb-6 text-center">Survey Form</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-4">
                        <label htmlFor="email" className="block text-gray-700 font-bold mb-2">
                            Email
                        </label>
                        <input
                            type="email"
                            id="email"
                            name="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label htmlFor="address" className="block text-gray-700 font-bold mb-2">
                            Address
                        </label>
                        <input
                            type="text"
                            id="address"
                            name="address"
                            value={address}
                            onChange={(e) => setAddress(e.target.value)}
                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label htmlFor="county" className="block text-gray-700 font-bold mb-2">
                            County
                        </label>
                        <input
                            type="text"
                            id="county"
                            name="county"
                            value={county}
                            onChange={(e) => setCounty(e.target.value)}
                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label htmlFor="state" className="block text-gray-700 font-bold mb-2">
                            State
                        </label>
                        <input
                            type="text"
                            id="state"
                            name="state"
                            value={state}
                            onChange={(e) => setState(e.target.value)}
                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label htmlFor="zipCode" className="block text-gray-700 font-bold mb-2">
                            ZipCode
                        </label>
                        <input
                            type="number"
                            id="zipCode"
                            name="zipCode"
                            value={zipcode}
                            onChange={(e) => setZipcode(e.target.value)}
                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
                            required
                        />
                    </div>
                    <div className="flex justify-center">
                        <button
                            type="submit"
                            className="px-4 py-2 bg-blue-600 text-white font-bold rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-600"
                        >
                            Submit
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
}
